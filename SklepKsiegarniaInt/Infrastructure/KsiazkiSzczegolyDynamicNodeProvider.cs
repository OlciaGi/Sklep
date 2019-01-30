using MvcSiteMapProvider;
using SklepKsiegarniaInt.DAL;
using SklepKsiegarniaInt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKsiegarniaInt.Infrastructure
{
    public class KsiazkiSzczegolyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private KsiazkiContext db = new KsiazkiContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Ksiazka ksiazka in db.Ksiazki)
            {
                DynamicNode node = new DynamicNode();
                node.Title = ksiazka.TytulKsiazki;
                node.Key = "Ksiazka_" + ksiazka.KsiazkaId;
                node.ParentKey = "Kategoria_" + ksiazka.KategoriaId;
                node.RouteValues.Add("id", ksiazka.KsiazkaId);
                returnValue.Add(node);
            }

            return returnValue;
        }
    }
}

   