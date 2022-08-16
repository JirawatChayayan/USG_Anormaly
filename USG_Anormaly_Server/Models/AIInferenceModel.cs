using USG_Anormaly_DL_lib;
using USG_Anormaly_lib;
namespace USG_Anormaly_Server.Models
{
    public class AIInferenceModel
    {
        public string b64Img { get; set; }
        public string recipe { get; set; }
        public CameraIdx CameraIdx { get; set; }
        public bool reqImgDisplay { get; set; } = false;
    }
}
