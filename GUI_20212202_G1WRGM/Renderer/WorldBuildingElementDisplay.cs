using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUI_20212202_G1WRGM.Renderer
{
    public class WorldBuildingElementDisplay : FrameworkElement
    {
        // ez meg minden statikus elemet rajzolni ki az adott mapen, ennek a kidolgozásával kezdek inkább

        // fogalmam sincs jelenleg hogy itt az IList jó e, de elvileg lehet alá observablet meg mindent tolni szóval majd később ez még elválik, ennyire nem látom át még az egészet
        IList<WorldBuildingElement> worldBuildingElements;

        public void Setup(IList<WorldBuildingElement> worldBuildingElements)
        {
            this.worldBuildingElements = worldBuildingElements;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            // na és akkor itt csak a listában lévő dolgokat rajzolgatja ki, amihez jelenleg nincsenek képeim stb.
            // de ha bármi egyéb dolog kell akkor elsősorban ne függőséggel oldjuk meg hanem pl.: a modelbe csapjunk oda +1 property ha azzal megoldható
            // ++ csak ne felejtsük el EF-ben hogy kell a mappelni, hogy ha nem .Ignore() stb.
        }



    }
}
