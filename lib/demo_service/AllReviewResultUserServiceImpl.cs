using demo_common;
using demo_model;
using demo_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class AllReviewResultUserServiceImpl : IAllReviewResultUserService
    {
        private readonly IAllReviewResultUserRepo _repo;
        private readonly ICreterialLevelRepo _criterialRepo;
        private readonly IReviewResultRepo _reviewResultRepo;
        private readonly ICriteriaByCapacityRepo _criteriaByCapacityRepo;
        private readonly IReviewPeriodRepo _reviewPeriodRepo;
        private readonly IStaffRepo _staffRepo;
        public AllReviewResultUserServiceImpl(IAllReviewResultUserRepo repo, ICreterialLevelRepo criterialRepo, 
            IReviewResultRepo reviewResultRepo, ICriteriaByCapacityRepo criteriaByCapacityRepo, IReviewPeriodRepo reviewPeriodRepo, IStaffRepo staffRepo)
        {
            this._repo = repo;
            this._criterialRepo = criterialRepo;
            this._reviewResultRepo = reviewResultRepo;
            this._criteriaByCapacityRepo = criteriaByCapacityRepo;
            this._reviewPeriodRepo = reviewPeriodRepo;
            this._staffRepo = staffRepo;
        }

        public ResponseMessage GetAllReviewResultUser(int staffId)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllReviewResultUsers(staffId);
                rp.message = "lấy tất cả bài đánh giá nhân viên thành công";
                rp.errorcode = 0;
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
                rp.errorcode = -1;
            }
            return rp;
        }
        public float CriterialResult(List<AllReviewResultUser> list, int criteriaid)
        {
            var a = list.Where(x => x.criteriaid == criteriaid).ToList();
            float sum = 0;
            float assessor = 0;
            foreach (var item in a)
            {
                float heso = 0;
                if (item.assessorid == null)
                {
                    heso = 1;
                }
                if (item.assessorid != null)
                {
                    if (item.userduocdanhgia == item.assessorid)
                    {
                        heso = 1;
                    }
                    else
                    {
                        heso = item.ratingcoefficient;
                    }
                }
                sum += item.point * heso;
                assessor += heso;
            }
            float avarage = sum / assessor;
            return avarage;
        }
        public ResponseMessage GetReviewResultUserByKey(int staffId, int pathid, int reviewid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                var list = _repo.GetAllReviewResultUsersByUseridAndReviewId(reviewid, staffId);
                /*float sumCriterial1 = CriterialResult(list, 1);
                float sumCriterial2 = CriterialResult(list, 2);   
                float sumCriterial3 = CriterialResult(list, 3);
                float sumCriterial4 = CriterialResult(list, 4);
                float sumCriterial5 = CriterialResult(list, 5);
                float sumCriterial6 = CriterialResult(list, 6);*/


                /*   List<float> listcriteria = new List<float>
               {
                   sumCriterial1 , sumCriterial2 , sumCriterial3 , sumCriterial4 , sumCriterial5 , sumCriterial6
               };*/

                List<float> listcriteria = new List<float>();
                //lấy danh sách tiêu chí của khung năng lực theo pathid
                var listCriterial = _criteriaByCapacityRepo.GetCriteriaByPathid(pathid);
                foreach (var item in listCriterial)
                {
                    float a = CriterialResult(list, item.criteriaid);
                    listcriteria.Add(a);
                }

                var listCriterialCompare = _criterialRepo.GetAllCriterialLevel(pathid);
                CriterialLevel? result = null;
                if (listCriterialCompare != null && listCriterialCompare.Count > 0)
                {
                    int maxLevel = listCriterialCompare[listCriterialCompare.Count - 1].nodeid;// lấy node cao nhất
                    bool isnotcontinue = false;
                    for (int i = 1; i <= maxLevel; i++)
                    {
                        var listdata = listCriterialCompare.Where(x => x.nodeid == i).ToList();
                        float criteria = -1;// diem trung bình
                        for (int j = 0; j < listdata.Count; j++)
                        {
                            criteria = listcriteria[listdata[j].criteriaid - 1];
                            if (listdata[j].point <= criteria)
                            {
                                result = listdata[j];
                            }
                            else
                            {
                                isnotcontinue = true;
                                break;
                            }
                        }
                        if (isnotcontinue)
                        {
                            break;
                        }
                    }
                }
                if (result != null)
                {
                    result.userid = staffId;
                    var staffname = _repo.GetAllStaff(staffId);
                    foreach (var item in staffname)
                    {
                        result.staffname = item.staffName;
                    }
                    _reviewResultRepo.UpdateReviewResult(list[0].reviewresultsid, result.nodeid);
                    _repo.UpdateStaff(staffId, result.nodeid, result.levelname);
                }
                rp.status = MessageStatus.success;
                rp.data = result;
                rp.message = "lấy tất cả bài đánh giá nhân viên theo key thành công";
                rp.errorcode = 0;
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
                rp.errorcode = -1;
            }
            return rp;
        }

        public ResponseMessage GetReviewResultUserByUserid(int staffid, int reviewid)
        {


            ResponseMessage rp = new ResponseMessage();
            try
            {
                //lấy danh sách đợt đánh giá
                //lấy đợt gần nhất
                var listReviewPeriod = _reviewPeriodRepo.GetAllReviewPeriod();

                var listGetAllByStaffid = _repo.GetAllReviewResultUsersByUseridAndReviewId(reviewid, staffid);

                /*var a=listGetAllByStaffid.GroupBy(x=> new {x.userdanhgia ,x.ratingcoefficient}).Select(i=> new GetAllReviewResultUser
                {
                    userdanhgia=i.Key.userdanhgia,
                    dataReview=i.ToList()
                }).ToList();*/

                var a = listGetAllByStaffid.GroupBy(x => x.userdanhgia).Select(i => new GetAllReviewResultUser
                {
                    userdanhgia = i.Key,
                    dataReview = i.ToList().OrderBy(x => x.criteriaid).ToList(),
                }).ToList().OrderByDescending(x=>x.userdanhgia== staffid).ToList();

                rp.status = MessageStatus.success;
                rp.data = a;
                rp.message = "lấy tất cả bài đánh giá nhân viên thành công";
                rp.errorcode = 0;
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
                rp.errorcode = -1;
            }
            return rp;
        }

        public ResponseMessage GetAverageReviewResultUser(int staffId, int pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                GetAllAverageReviewResultUser getAllAverageReviewResultUser = new GetAllAverageReviewResultUser();
                var userInfo = _staffRepo.GetStaffByUserId(staffId);
                var list = _repo.GetAllReviewResultUsers(staffId);


                 List<float> listcriteria = new List<float>();
                 //lấy danh sách tiêu chí của khung năng lực theo pathid
                 var listCriterial = _criteriaByCapacityRepo.GetCriteriaByPathid(pathid);
                 List<GetCriteriaLevelAverage> newList = new List<GetCriteriaLevelAverage>();
                 foreach (var item in listCriterial)
                 {
                     float a = CriterialResult(list, item.criteriaid);
                     GetCriteriaLevelAverage criteriaByCapacity = new GetCriteriaLevelAverage();
                     criteriaByCapacity.criteriaid = item.criteriaid;
                     criteriaByCapacity.criterianame = item.criterianame;
                     criteriaByCapacity.unit = item.unit;
                     criteriaByCapacity.point = a;
                     newList.Add(criteriaByCapacity);
                     listcriteria.Add(a);
                 }
                 getAllAverageReviewResultUser.staff = userInfo[0];
                 getAllAverageReviewResultUser.dataReview = newList;
                rp.status = MessageStatus.success;
                rp.data = getAllAverageReviewResultUser;
                rp.message = "lấy các user để so sánh thành công";
                rp.errorcode = 0;
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
                rp.errorcode = -1;
            }
            return rp;
        }

        public List<GetAllAverageReviewResultUser> GetAverageReview(int pathid)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage GetUserCompare(int pathid, int reviewid, int userid1, int userid2)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                GetUserCompare getUserCompare = new GetUserCompare();
                var user1 = GetOnlyUserCompare(userid1, pathid, reviewid);
                var user2 = GetOnlyUserCompare(userid2, pathid, reviewid);
                getUserCompare.user1 = user1;
                getUserCompare.user2 = user2;
                rp.status = MessageStatus.success;
                rp.data = getUserCompare;
                rp.message = "lấy các user để so sánh thành công";
                rp.errorcode = 0;
            }
            catch (Exception ex)
            {
                rp.status = MessageStatus.error;
                rp.message = ex.Message;
                rp.data = null;
                rp.errorcode = -1;
            }
            return rp;
        }
        public GetAllAverageReviewResultUser GetOnlyUserCompare(int userid, int pathid, int reviewid) {
            GetAllAverageReviewResultUser getAllAverageReviewResultUser = new GetAllAverageReviewResultUser();
            try
            {
                var userInfo = _staffRepo.GetStaffByUserId(userid);
                var list = _repo.GetAllReviewResultUsersByUseridAndReviewId(reviewid, userid);                  
                List<GetCriteriaLevelAverage> newList = new List<GetCriteriaLevelAverage>();
                if (list.Count>0)
                {
                    //lấy danh sách tiêu chí của khung năng lực theo pathid
                    var listCriterial = _criteriaByCapacityRepo.GetCriteriaByPathid(pathid);
                    foreach (var item in listCriterial)
                    {
                        float a = CriterialResult(list, item.criteriaid);
                        GetCriteriaLevelAverage criteriaByCapacity = new GetCriteriaLevelAverage();
                        criteriaByCapacity.criteriaid = item.criteriaid;
                        criteriaByCapacity.criterianame = item.criterianame;
                        criteriaByCapacity.unit = item.unit;
                        criteriaByCapacity.point = a;
                        newList.Add(criteriaByCapacity);
                    }
                }
                else
                {
                    newList = new List<GetCriteriaLevelAverage>();
                }
                getAllAverageReviewResultUser.staff = userInfo[0];
                getAllAverageReviewResultUser.dataReview = newList;
            }
            catch (Exception ex)
            {
                return null;
            }
            return getAllAverageReviewResultUser;
        }
    }
}
