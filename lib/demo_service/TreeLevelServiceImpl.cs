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
    public class TreeLevelServiceImpl : ITreeLevelService
    {
        public readonly ITreeLevelRepo _repo;
        public TreeLevelServiceImpl(ITreeLevelRepo repo)
        {
            _repo = repo;
        }

            public List<NodeLevelStructure> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public ResponseMessage GetAllLevel()
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllEmployee();
                rp.message = "lấy tất cả nhân viên thành công";
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

        public List<NodeLevelStructure> GetTreeByUsername(int nodeid)
        {
            throw new NotImplementedException();
        }

        public NodeGetTreeLevelStructure GetTreeByUsername()
        {
            NodeGetTreeLevelStructure result = new NodeGetTreeLevelStructure();
            result.nodes = new List<NodeChartLevelStructureOutput<NodeLevelStructure>>();
            result.edges = new List<NodeEdgeChartNode>();
            result.levels =_repo.GetAllEmployee().ToList();
            try
            {
                List<NodeLevelStructure> list = _repo.GetAllEmployee();

                foreach (var item in list)
                {
                    var returnval = _repo.GetTreeByUsername(item.nodeid);
                    GetNodeTreeRoot(ref result, returnval, item.nodeid);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        private void GetNodeTreeRoot(ref NodeGetTreeLevelStructure result, List<NodeLevelStructure> listemployeestructure, int username)
        {
            if (listemployeestructure == null || listemployeestructure.Count == 0)
            {
                return;
            }
            //lấy thông tin của user đang tìm kiếm
            var objUserRoot = listemployeestructure.Find(x => x.nodeid == username);
            if (objUserRoot != null)
            {
                //Lấy thông tin của headuser
                var objHeadUser = listemployeestructure.Find(x => x.nodeid == objUserRoot.parentid);
                var listChildren = listemployeestructure.Where(x => x.parentid == username).ToList();
                int maxNumberNode = listChildren.Count > 0 ? listChildren.Count : 1;
                //Kích thước màn hình= tổng số node con * kích thước node + (tổng số node con +1) * kích thước từng node
                float screenWidth = (maxNumberNode * ConstLevelStructureSize.NodeWidth) + ((maxNumberNode + 1) * ConstLevelStructureSize.DistanceCol);
                float rootpositionx = (screenWidth - ConstLevelStructureSize.NodeWidth) / 2;//Trung điểm - 1/2 node
                HandleNodeTree(ref result, rootpositionx, listChildren, objHeadUser, objUserRoot);
            }
        }
        private void HandleNodeTree(ref NodeGetTreeLevelStructure result, float rootpositionx, List<NodeLevelStructure> listChildren, NodeLevelStructure objHeadUser = null, NodeLevelStructure objUserRoot = null, int classid = 0)
        {

            if (objHeadUser != null)
            {
                var nodePositonY = classid * (ConstLevelStructureSize.NodeHeight + ConstLevelStructureSize.DistanceRow);

                //Lấy vị trí
                NodeChartLevelStructureOutput<NodeLevelStructure> listnode = new NodeChartLevelStructureOutput<NodeLevelStructure>();
                listnode.listdata = new List<NodeChartLevelStructureDataOutput<NodeLevelStructure>>();
                NodeChartLevelStructureDataOutput<NodeLevelStructure> node = new NodeChartLevelStructureDataOutput<NodeLevelStructure>();
                node.position = new NodeCoordinateChart();
                node.id = objHeadUser.nodeid;
                node.type = string.Format("level_{0}", objHeadUser.levelid);
                node.data = objHeadUser;
                node.position.x = rootpositionx;
                node.position.y = nodePositonY;
                node.classid = classid;
                node.isdisable = true;//sử dụng cho xem cấu trúc siêu thị để disable headeruser
                listnode.listdata.Add(node);
                listnode.classid = classid;
                //result.nodes.Add(listnode);

                //Lấy đường kết nối các node
                NodeEdgeChartNode edge = new NodeEdgeChartNode();
                edge.source =objHeadUser.parentid.ToString();
                edge.target = objHeadUser.nodeid.ToString();
                result.edges.Add(edge);
            }

            if (objUserRoot != null)
            {
                classid += 1;
                var nodePositonY = classid * (ConstLevelStructureSize.NodeHeight + ConstLevelStructureSize.DistanceRow);
                //Lấy vị trí
                NodeChartLevelStructureOutput<NodeLevelStructure> listnode = new NodeChartLevelStructureOutput<NodeLevelStructure>();
                listnode.listdata = new List<NodeChartLevelStructureDataOutput<NodeLevelStructure>>();
                NodeChartLevelStructureDataOutput<NodeLevelStructure> node = new NodeChartLevelStructureDataOutput<NodeLevelStructure>();
                node.position = new NodeCoordinateChart();
                node.id = objUserRoot.nodeid;
                node.type = string.Format("level_{0}", objUserRoot.levelid);
                node.data = objUserRoot;
                node.position.x = rootpositionx;
                node.position.y = nodePositonY;
                node.classid = classid;
                listnode.listdata.Add(node);
                listnode.classid = classid;
                //result.nodes.Add(listnode);

                //Lấy đường kết nối các node
                NodeEdgeChartNode edge = new NodeEdgeChartNode();
                edge.source = objUserRoot.parentid.ToString();
                edge.target = objUserRoot.nodeid.ToString();
                result.edges.Add(edge);
            }

            if (listChildren.Count > 0)
            {
                classid += 1;
                var nodePositonY = classid * (ConstLevelStructureSize.NodeHeight + ConstLevelStructureSize.DistanceRow);
                float beginChildPositonX = 0;//Lấy tọa độ của node con đầu tiên
                if (listChildren.Count % 2 == 0)//Số node con là số chẵn
                {
                    beginChildPositonX = rootpositionx + (ConstLevelStructureSize.NodeWidth + ConstLevelStructureSize.DistanceCol) / 2 - (ConstLevelStructureSize.NodeWidth + ConstLevelStructureSize.DistanceCol) * listChildren.Count / 2;
                }
                else//số node con là số lẻ
                {
                    beginChildPositonX = rootpositionx - (ConstLevelStructureSize.NodeWidth + ConstLevelStructureSize.DistanceCol) * (listChildren.Count / 2);
                }
                NodeChartLevelStructureOutput<NodeLevelStructure> listnode = new NodeChartLevelStructureOutput<NodeLevelStructure>();
                listnode.listdata = new List<NodeChartLevelStructureDataOutput<NodeLevelStructure>>();
                for (int i = 0; i < listChildren.Count; i++)
                {
                    if (!listChildren[i].isold)
                    {
                        NodeEdgeChartNode edge = new NodeEdgeChartNode();
                        edge.source = listChildren[i].parentid.ToString();
                        edge.target = listChildren[i].nodeid.ToString();
                        result.edges.Add(edge);
                    }
                    //Lấy đường kết nối các node, loại bỏ các liên kết đã có
                    NodeChartLevelStructureDataOutput<NodeLevelStructure> node = new NodeChartLevelStructureDataOutput<NodeLevelStructure>();
                    node.position = new NodeCoordinateChart();
                    node.id = listChildren[i].nodeid;
                    node.type = string.Format("level_{0}", listChildren[i].levelid);
                    node.data = listChildren[i];
                    node.position.x = beginChildPositonX + i * (ConstLevelStructureSize.NodeWidth + ConstLevelStructureSize.DistanceCol);
                    node.position.y = nodePositonY;
                    node.classid = classid;
                    listnode.listdata.Add(node);
                    listnode.classid = classid;
                }
                //result.nodes.Add(listnode);
                //GetTreeDetail?jobdepartmentid
            }
        }
    }
}
