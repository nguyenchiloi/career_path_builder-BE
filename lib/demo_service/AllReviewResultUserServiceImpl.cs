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
        public AllReviewResultUserServiceImpl(IAllReviewResultUserRepo repo, ICreterialLevelRepo criterialRepo, IReviewResultRepo reviewResultRepo, ICriteriaByCapacityRepo criteriaByCapacityRepo)
        {
            this._repo = repo;
            this._criterialRepo = criterialRepo;
            this._reviewResultRepo = reviewResultRepo;
            this._criteriaByCapacityRepo = criteriaByCapacityRepo;
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
        public ResponseMessage GetReviewResultUserByKey(int staffId, int pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                var list = _repo.GetAllReviewResultUsers(staffId);
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

        public ResponseMessage GetReviewResultUserByUserid(int staffid)
        {


            ResponseMessage rp = new ResponseMessage();
            try
            {
                var listGetAllByStaffid = _repo.GetAllReviewResultUsers(staffid);

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
    }
}
