using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGame.ConsoleGame.Extensions
{
    public static class TestExtensionDemo
    {
       // public static readonly IGetMapSize defaultImplementation = new GetMapSize();
        public static IGetMapSize Implementation { private get; set; } = new GetMapSize();
        public static int GetMapSizeFor(this IConfiguration config, string value)
        {
            return Implementation.GetMapSizeFor(config, value);
        } 
    }

    public class GetMapSize : IGetMapSize
    {
        public int GetMapSizeFor(IConfiguration config, string value)
        {
            var section = config.GetSection("game:mapsettings");
            return int.TryParse(section[value], out int result) ? result : 0;
        }
    }

    public interface IGetMapSize
    {
        int GetMapSizeFor(IConfiguration config, string value);
    }
}
