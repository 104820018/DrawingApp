using DrawingModel;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DrawingForm.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        GoogleDriveService _service;

        public PresentationModel(Model model, Control canvas)
        {
            this._model = model;
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
        }

        // Draw the shape
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        // Check if line botton is enabled
        public bool IsLineEnabled()
        {
            if (_model.IsLine())
                return false;
            else
                return true;
        }

        // Check if rectangle botton is enabled
        public bool IsRectangleEnabled()
        {
            if (_model.IsRectangle())
                return false;
            else
                return true;
        }

        // Check if rectangle botton is enabled
        public bool IsEllipseEnabled()
        {
            if (_model.IsEllipse())
                return false;
            else
                return true;
        }

        // Check if arrow botton is enabled
        public bool IsArrowEnabled()
        {
            if (_model.IsArrow())
                return false;
            else
                return true;
        }

        // Check if arrow botton is enabled
        public bool IsDeleteEnabled()
        {
            if (_model.IsDelete())
                return true;
            else
                return false;
        }

        // Check if rectangle botton is enabled
        public bool IsSaveToGoogleDriveEnabled()
        {
            if (_model.GetShapeList().Count == 0)
                return false;
            else
                return true;
        }

        // Save file on google drive
        public void SaveFile()
        {
            const string CONTENT_TYPE = "image/jpeg";
            const string UPLOAD_FILE_NAME = "My Drawing.jpg";
            _service.UploadFile(UPLOAD_FILE_NAME, CONTENT_TYPE);
        }

        // Download file from google drive
        public void DownloadFile()
        {
            const string DOWNLOAD_FILE_ON_DRIVE_NAME = "My Drawing.jpg";
            const string DOWNLOAD_FILE_PATH = "./";
            List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File foundFile = fileList.Find (item => 
            {
                return item.Title == DOWNLOAD_FILE_ON_DRIVE_NAME;
            });
            if (foundFile != null)
                _service.DownloadFile(foundFile, DOWNLOAD_FILE_PATH);
        }
    }
}