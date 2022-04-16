using GUI_20212202_G1WRGM.Logic;
using GUI_20212202_G1WRGM.Renderer.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GUI_20212202_G1WRGM.Renderer
{
    public class MapDisplay : FrameworkElement, IMapDisplay
    {
        // Ez meg tulajdonképpen semmi mást nem csinálna csak az adott level nagyságáért felel xpixel*ypixel ++ esetleg alap hátteret állít az egészre meg ilyenek
        public IList<Map> Maps { get; set; }
        int currentLevel;
        public System.Drawing.Size size { get; set; }

        public void Resize(System.Drawing.Size size)
        {
            // Ez amúgy itt így nem lesz jó mert a map size != a képernyő méretével, ezért mondtam korábban, hogy 2 méret lesz a map-é meg a képernyőé
            // A képernyőé függ az ablakmérettől a map méretét pedig mi adjuk meg

            //this.size = size;
            //if (Maps != null)
            //{
            //    Maps.Size = size;
            //    this.InvalidateVisual();
            //}
        }

        public void SetupMap(IList<Map> maps)
        {
            this.Maps = maps;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            //if (map != null)
            //{
            //    //Display WorldBuildingElements
            //    int xElement = 0;
            //    foreach (WorldBuildingElement worldElement in map.WorldElements)
            //    {
            //        drawingContext.DrawRectangle(
            //            new ImageBrush(new BitmapImage(worldElement.PathToImg)),
            //            new Pen(Brushes.Black, 0),
            //            new Rect(xElement, map.Size.Height - map.Size.Height / 24, map.Size.Width / 12, map.Size.Height / 24));

            //        xElement += map.Size.Width / 12;
            //    }
            //}
        }
    }
}
