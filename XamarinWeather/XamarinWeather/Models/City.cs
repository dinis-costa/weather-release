using Newtonsoft.Json;

namespace XamarinWeather.Models
{
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("local_names")]
        public LocalNames LocalNames { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class LocalNames
    {
        [JsonProperty("hr")]
        public string Hr { get; set; }

        [JsonProperty("pa")]
        public string Pa { get; set; }

        [JsonProperty("cv")]
        public string Cv { get; set; }

        [JsonProperty("ku")]
        public string Ku { get; set; }

        [JsonProperty("ru")]
        public string Ru { get; set; }

        [JsonProperty("br")]
        public string Br { get; set; }

        [JsonProperty("ba")]
        public string Ba { get; set; }

        [JsonProperty("so")]
        public string So { get; set; }

        [JsonProperty("gv")]
        public string Gv { get; set; }

        [JsonProperty("cs")]
        public string Cs { get; set; }

        [JsonProperty("wa")]
        public string Wa { get; set; }

        [JsonProperty("lb")]
        public string Lb { get; set; }

        [JsonProperty("kk")]
        public string Kk { get; set; }

        [JsonProperty("is")]
        public string Is { get; set; }

        [JsonProperty("yi")]
        public string Yi { get; set; }

        [JsonProperty("sc")]
        public string Sc { get; set; }

        [JsonProperty("bn")]
        public string Bn { get; set; }

        [JsonProperty("ga")]
        public string Ga { get; set; }

        [JsonProperty("la")]
        public string La { get; set; }

        [JsonProperty("he")]
        public string He { get; set; }

        [JsonProperty("ps")]
        public string Ps { get; set; }

        [JsonProperty("el")]
        public string El { get; set; }

        [JsonProperty("sr")]
        public string Sr { get; set; }

        [JsonProperty("sk")]
        public string Sk { get; set; }

        [JsonProperty("zu")]
        public string Zu { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }

        [JsonProperty("ur")]
        public string Ur { get; set; }

        [JsonProperty("nl")]
        public string Nl { get; set; }

        [JsonProperty("et")]
        public string Et { get; set; }

        [JsonProperty("mr")]
        public string Mr { get; set; }

        [JsonProperty("my")]
        public string My { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("zh")]
        public string Zh { get; set; }

        [JsonProperty("hu")]
        public string Hu { get; set; }

        [JsonProperty("th")]
        public string Th { get; set; }

        [JsonProperty("fr")]
        public string Fr { get; set; }

        [JsonProperty("gu")]
        public string Gu { get; set; }

        [JsonProperty("bo")]
        public string Bo { get; set; }

        [JsonProperty("wo")]
        public string Wo { get; set; }

        [JsonProperty("or")]
        public string Or { get; set; }

        [JsonProperty("ml")]
        public string Ml { get; set; }

        [JsonProperty("ha")]
        public string Ha { get; set; }

        [JsonProperty("ln")]
        public string Ln { get; set; }

        [JsonProperty("ko")]
        public string Ko { get; set; }

        [JsonProperty("uk")]
        public string Uk { get; set; }

        [JsonProperty("oc")]
        public string Oc { get; set; }

        [JsonProperty("tl")]
        public string Tl { get; set; }

        [JsonProperty("an")]
        public string An { get; set; }

        [JsonProperty("sq")]
        public string Sq { get; set; }

        [JsonProperty("fy")]
        public string Fy { get; set; }

        [JsonProperty("ug")]
        public string Ug { get; set; }

        [JsonProperty("hi")]
        public string Hi { get; set; }

        [JsonProperty("be")]
        public string Be { get; set; }

        [JsonProperty("mi")]
        public string Mi { get; set; }

        [JsonProperty("ja")]
        public string Ja { get; set; }

        [JsonProperty("lt")]
        public string Lt { get; set; }

        [JsonProperty("bs")]
        public string Bs { get; set; }

        [JsonProperty("ka")]
        public string Ka { get; set; }

        [JsonProperty("tt")]
        public string Tt { get; set; }

        [JsonProperty("km")]
        public string Km { get; set; }

        [JsonProperty("am")]
        public string Am { get; set; }

        [JsonProperty("lv")]
        public string Lv { get; set; }

        [JsonProperty("te")]
        public string Te { get; set; }

        [JsonProperty("af")]
        public string Af { get; set; }

        [JsonProperty("sl")]
        public string Sl { get; set; }

        [JsonProperty("gn")]
        public string Gn { get; set; }

        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("ta")]
        public string Ta { get; set; }

        [JsonProperty("fa")]
        public string Fa { get; set; }

        [JsonProperty("yo")]
        public string Yo { get; set; }

        [JsonProperty("ky")]
        public string Ky { get; set; }

        [JsonProperty("sv")]
        public string Sv { get; set; }

        [JsonProperty("gl")]
        public string Gl { get; set; }

        [JsonProperty("ht")]
        public string Ht { get; set; }

        [JsonProperty("za")]
        public string Za { get; set; }

        [JsonProperty("bg")]
        public string Bg { get; set; }

        [JsonProperty("eu")]
        public string Eu { get; set; }

        [JsonProperty("kn")]
        public string Kn { get; set; }

        [JsonProperty("hy")]
        public string Hy { get; set; }

        [JsonProperty("cu")]
        public string Cu { get; set; }

        [JsonProperty("es")]
        public string Es { get; set; }

        [JsonProperty("fi")]
        public string Fi { get; set; }

        [JsonProperty("mn")]
        public string Mn { get; set; }

        [JsonProperty("co")]
        public string Co { get; set; }

        [JsonProperty("ca")]
        public string Ca { get; set; }

        [JsonProperty("li")]
        public string Li { get; set; }

        [JsonProperty("vi")]
        public string Vi { get; set; }

        [JsonProperty("sh")]
        public string Sh { get; set; }

        [JsonProperty("tk")]
        public string Tk { get; set; }

        [JsonProperty("ne")]
        public string Ne { get; set; }

        [JsonProperty("eo")]
        public string Eo { get; set; }

        [JsonProperty("pl")]
        public string Pl { get; set; }

        [JsonProperty("tg")]
        public string Tg { get; set; }

        [JsonProperty("uz")]
        public string Uz { get; set; }

        [JsonProperty("mk")]
        public string Mk { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("kv")]
        public string Kv { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }

        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("gd")]
        public string Gd { get; set; }

        [JsonProperty("pt")]
        public string Pt { get; set; }
    }
}
