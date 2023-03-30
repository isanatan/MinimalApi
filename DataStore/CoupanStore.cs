using System;

public static class CoupanStore
{
    public static List<Coupan> coupansList = new List<Coupan> {
        new Coupan(1,"100OFF", new DateTime(2023, 02, 18), true, new DateTime(2023, 02, 26)),
        new Coupan(2,"200OFF", new DateTime(2023, 01, 18), true, new DateTime(2023, 03, 18))
     };
}
