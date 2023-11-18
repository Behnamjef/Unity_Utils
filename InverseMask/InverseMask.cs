using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace MagicOwl.UI
{
    public class InverseMask : Image
    {
        private static readonly int StencilComp = Shader.PropertyToID("_StencilComp");

        public override Material materialForRendering
        {
            get
            {
                var forRendering = new Material(base.materialForRendering);
                forRendering.SetInt(StencilComp, (int)CompareFunction.NotEqual);
                return forRendering;
            }
        }
    }
}
