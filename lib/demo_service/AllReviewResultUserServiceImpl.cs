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
        public AllReviewResultUserServiceImpl(IAllReviewResultUserRepo repo, ICreterialLevelRepo criterialRepo)
        {
            this._repo = repo;
            this._criterialRepo = criterialRepo;
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
        public float CriterialResult(List<AllReviewResultUser> list, int criteriaid) { 
            var a=list.Where(x=>x.criteriaid==criteriaid).ToList();
            float sum = 0;
            float assessor = 0;
            foreach (var item in a)
            {
                float heso = 0;
                if (item.assessorid == null)
                {
                    heso = 1;
                }
                if(item.assessorid != null)
                {
                    if (item.userdanhgia == item.userduocdanhgia)
                    {
                        heso = 1;
                    }
                    else
                    {
                        heso = item.ratingcoefficient;
                    }
                }
                sum+= item.point * heso;
                assessor += heso;
            }
            float avarage = sum / assessor;
            return avarage;
        }
        public ResponseMessage GetReviewResultUserByKey(int staffId)
        {
            ResponseMessage rp = new ResponseMessage();
            var list = _repo.GetAllReviewResultUsers(staffId);
            float sumCriterial1 = CriterialResult(list, 1);
            float sumCriterial2 = CriterialResult(list, 2);
            float sumCriterial3 = CriterialResult(list, 3);
            float sumCriterial4 = CriterialResult(list, 4);
            float sumCriterial5 = CriterialResult(list, 5);
            float sumCriterial6 = CriterialResult(list, 6);


            var listCriterialCompare = _criterialRepo.GetAllCriterialLevel(1);
            var search = listCriterialCompare.Where(x => x.criteriaid == 2 && x.point <= sumCriterial2);
            try
            {
                rp.status = MessageStatus.success;
                rp.data = sumCriterial2;
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
