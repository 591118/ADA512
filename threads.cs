class Tråd {

    static void Main (String[] args) {

        List<int> meldingsKø = new List <int> ();
        Random r = new Random();
        EventWaitHandle e = new EventWaitHandle(false, EventResetMode.AutoReset);

        //trådargumenter
        List<object> targ = new List<object>();
        
        targ.Add(kø);
        targ.Add(r);
        targ.Add(e);

        // Starte hjelpetråden
        Thread t = new Thread(MeldingGenereator);
        T.start(targ);

        while (true) {
            e.WaitOne();    //Blokkerer hovedtråden til en annen tråd "åpner" igjen, og "lukker" tråden igjen automatisk ved autoreset
            while(kø.Count > 0) {
                Console.Write ("Hovedtråden {0} " , Thread.CurrentThread.MangedThreadId);
                Console.writeLine("fjerner {0}", kø[0]);
                meldingsKø.RemoveAt(0);
            }
        }
    
    }

    static void MeldingGenereator (){
       List<object> targ = o as List<object>;
       List<int> meldingsKø = targ[0] as List <int>;
       Random r = targ[1] as Random;
       EventWaitHandle e = targ[2] as EventWaitHandle;

       for(int i = 0 ; i < 100 ; i++){
        int sovetid = r.Next(1000,3000);
        Thread.sleep(sovetid);

        int antallMeldinger = r.Next(0,3);

        for(int j = 0 ; j < antallMeldinger ; j++){
                meldingsKø.Add(r.Next(0,9));
                Console.Write("Hjelpetråd {0} ", Thread.CurrentThread.MangedThreadId);
                Console.WriteLine("melding {0}", meldingsKø[meldingskø.Count-1]);
       }

        e.Set();        // "åpner døren"        -> 1 tråd kommer inn

    }

}

}