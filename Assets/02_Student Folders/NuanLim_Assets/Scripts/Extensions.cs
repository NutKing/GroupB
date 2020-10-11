
using UnityEngine;

namespace Assets._02_Student_Folders.NuanLim_Assets.Scripts {
    public static class Extensions {
        public static Vector3 copy(this Vector3 v) {
            return new Vector3(v.x, v.y, v.z);
        }
    }
}
