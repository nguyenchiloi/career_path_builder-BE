using demo_common;
using demo_model;
using demo_repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace demo_service
{
    public class LevelServiceImpl : ILevelService
    {
        private readonly ILevelRepo _repo;
        public LevelServiceImpl(ILevelRepo repo)
        {
            _repo = repo;
        }

        public ResponseMessage AddLevel(Level level)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.AddNewLevel(level.levelname, level.shortname, level.cycles, level.description, level.parentid, level.pathid, level.positionx, level.positiony, level.levelclass);
                rp.message = "Thêm mới level thành công";
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

        public ResponseMessage GetLevelByPathid(int pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = _repo.GetAllLevel(pathid);
                rp.message = "Thêm mới level thành công";
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

        public ResponseMessage GetTreeByPathid(int pathid)
        {
            ResponseMessage rp = new ResponseMessage();
            try
            {
                rp.status = MessageStatus.success;
                rp.data = GetTreeByPath(pathid);
                rp.message = "Lấy tree level thành công";
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

        public TreeLevel GetTreeByPath(int pathid)
        {
            TreeLevel treeLevel = new TreeLevel();
            List<TreeNodeLevel> treeNodeLevels = new List<TreeNodeLevel>();
            List<NodeEdgeChartNode> nodeEdgeChartNodes = new List<NodeEdgeChartNode>();
            var getLevel = _repo.GetAllLevel(pathid);
            foreach (var item in getLevel)
            {
                TreeNodeLevel treeNode = new TreeNodeLevel();
                treeNode.id = item.nodeid;
                treeNode.data = item;
                treeNode.levelclass = item.levelclass;
                NodeCoordinateChart nodeCoordinate=new NodeCoordinateChart();
                nodeCoordinate.x = item.positionx;
                nodeCoordinate.y = item.positiony;
                treeNode.position = nodeCoordinate;

                NodeEdgeChartNode edgeNode = new NodeEdgeChartNode();
                edgeNode.target = item.nodeid.ToString();
                edgeNode.source = item.parentid.ToString();

                treeNodeLevels.Add(treeNode);
                nodeEdgeChartNodes.Add(edgeNode);
            }
            treeLevel.nodes = treeNodeLevels;
            treeLevel.edges = nodeEdgeChartNodes;
            return treeLevel;
        }
    }
}
