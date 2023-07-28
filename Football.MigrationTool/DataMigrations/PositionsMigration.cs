using Football.Crosscutting.Enums;
using Microsoft.EntityFrameworkCore.Internal;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Football.MigrationTool.DataMigrations
{
    public class PositionsMigration
    {
        private IPlayerService _playerService;

        public PositionsMigration(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task Execute()
        {
            try
            {
                var players = await _playerService.GetPlayers(0, 0);

                foreach (var player in players)
                {
                    var values = Enum.GetNames(typeof(PositionEnum)).Select(x => x.ToLower()).ToList();
                    var values2 = Enum.GetValues(typeof(PositionEnum)).Cast<PositionEnum>();

                    int index = values.FindIndex(x => x == player.Position.ToLower());
                    //int index = Array.IndexOf(values, player.Position.ToLower());
                    if (index >= 0)
                    {
                        player.PositionCode = values2.ToList()[index];
                    }                  
                }
                await _playerService.UpdatePlayers(players);

            }
            catch (Exception ex)
            {

            }
        }
    }
}
