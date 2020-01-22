using Huiting.Common;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Service;
using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAnalysis.ChildControl
{
    public class ProjectListControl : UnitFreeLayoutPanel
    {
        ProjectData curData = null;
        IEnumerable<ProjectData> lstEntityData = null;
        Action<ProjectData> openProject;

        public IEnumerable<ProjectData> LstEntityData { get => lstEntityData; }
        public ProjectData CurData { get => curData; private set => curData = value; }

        public async void AsyncLoadData(Action<ProjectData> OpenProject)
        {
            this.openProject = OpenProject;
            IEnumerable<ProjectInfoDto> projectInfoDtos = await TaskEx.Run<IEnumerable<ProjectInfoDto>>(() => new ProjectInfoService().GetProjectInfoDtos());
            lstEntityData = from c in projectInfoDtos
                            select new ProjectData(c);

            lstEntityData = lstEntityData.Append(new ProjectData() { Text = "新建工程" });

            int dataCount = lstEntityData.Count();

            this.InitInterface(lstEntityData, IconLayoutType.TopImageBottomWord, true);

            this.ItemDoubleClick -= ProjectListControl_ItemDoubleClick;
            this.ItemDoubleClick += ProjectListControl_ItemDoubleClick;
        }

        private void ProjectListControl_ItemDoubleClick(object sender, EventArgs e)
        {
            this.curData = sender as ProjectData;
            List<ProjectData> lstProjectData = lstEntityData.Where(x => string.IsNullOrWhiteSpace(x.ID) == false).ToList();
            if (this.curData == null || string.IsNullOrEmpty(this.curData.ID))
            {
                FrmNewProject frmNewPro = new FrmNewProject(lstProjectData);
                if (frmNewPro.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                    return;
                this.curData = frmNewPro.CurData;
            }

            OnOpenProject(this.curData);
        }

        protected void OnOpenProject(ProjectData data)
        {
            if (openProject != null)
                openProject(data);
        }
    }
}
