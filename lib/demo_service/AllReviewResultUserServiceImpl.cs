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
        public AllReviewResultUserServiceImpl(IAllReviewResultUserRepo repo, ICreterialLevelRepo criterialRepo, IReviewResultRepo reviewResultRepo)
        {
            this._repo = repo;
            this._criterialRepo = criterialRepo;
            this._reviewResultRepo = reviewResultRepo;
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
            int assessor = 0;
            foreach (var item in a)
            {
                sum += item.point * item.assessorid;
                assessor += item.assessorid;
            }
            float avarage = sum / assessor;
            return avarage;
        }
        public ResponseMessage GetReviewResultUserByKey(int staffId)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                var list = _repo.GetAllReviewResultUsers(staffId);
                float sumCriterial1 = CriterialResult(list, 1);
                float sumCriterial2 = CriterialResult(list, 2);
                float sumCriterial3 = CriterialResult(list, 3);
                float sumCriterial4 = CriterialResult(list, 4);
                float sumCriterial5 = CriterialResult(list, 5);
                float sumCriterial6 = CriterialResult(list, 6);

                List<float> listcriteria = new List<float>
            {
                sumCriterial1 , sumCriterial2 , sumCriterial3 , sumCriterial4 , sumCriterial5 , sumCriterial6
            };

                var listCriterialCompare = _criterialRepo.GetAllCriterialLevel(2);
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
                _reviewResultRepo.UpdateReviewResult(list[0].reviewresultsid, result.nodeid);
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
    }
}
