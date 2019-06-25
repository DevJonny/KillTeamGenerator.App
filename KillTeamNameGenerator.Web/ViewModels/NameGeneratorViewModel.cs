using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KTNameGenerator.Core;
using KTNameGenerator.Core.Data;
using KTNameGenerator.Core.Model;
using Microsoft.AspNetCore.Components;

namespace KillTeamNameGenerator.Web.ViewModels
{
    public interface INameGeneratorViewModel
    {
        IEnumerable<Faction> Factions { get; }
        Faction SelectedFaction { get; set; }
        bool HasSubFactions { get; set; }

        void SelectFaction(UIChangeEventArgs e);
    }
    
    public class NameGeneratorViewModel : INameGeneratorViewModel
    {
        public IEnumerable<Faction> Factions => FactionData.Factions;
        public Faction SelectedFaction { get; set; }

        public bool HasSubFactions { get; set; }

        public void SelectFaction(UIChangeEventArgs e)
        {
            var factionType = (FactionType)Enum.Parse(typeof(FactionType), e.Value.ToString());

            SelectedFaction = KillTeam.FactionByType(factionType);
            HasSubFactions = SelectedFaction.HasSubFactions;
        }
    }
}