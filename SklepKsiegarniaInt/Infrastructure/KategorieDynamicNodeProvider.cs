using MvcSiteMapProvider;
using SklepKsiegarniaInt.DAL;
using SklepKsiegarniaInt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.Infrastructure
{
    public class KategorieDynamicNodeProvider : DynamicNodeProviderBase
    {
        private KsiazkiContext db = new KsiazkiContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Kategoria kategoria in db.Kategorie)
            {
                DynamicNode node = new DynamicNode();
                node.Title = kategoria.NazwaKategorii;
                node.Key = "Kategoria_" + kategoria.KategoriaId;
                node.RouteValues.Add("nazwaKategori", kategoria.KategoriaId);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}