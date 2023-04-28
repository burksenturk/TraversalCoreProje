﻿namespace TraversalCoreProje.CQRS.Results.DestinationResult
{
    public class GetAllDestinationQueryResult //entity mizin karşılık gelen parametrelerini tutar
    {
        public int id { get; set; }  //üye olmayan kullanıcı sadece bunları görsün istiyorum
        public string city { get; set; }
        public string daynight { get; set; }
        public double price { get; set; }
        public int capacity { get; set; }
    }
}
