package myapp.kinoisseminarska.webservices;

import java.util.List;

import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.dataholder.Show;
import myapp.kinoisseminarska.dataholder.TicketData;
import retrofit2.Call;
import retrofit2.Retrofit;
import retrofit2.converter.moshi.MoshiConverterFactory;

public class RestManagment {

    private static String baseURL = "https://kino20181203121922.azurewebsites.net/api/";

    private static Retrofit myRetrofit = new Retrofit.Builder()
            .baseUrl(baseURL)
            .addConverterFactory(MoshiConverterFactory.create())
            .build();


    public static Call<List<Show>> getPredstave() {
        return myRetrofit
                .create(GetShows.class)
                .getPredstave();
    }

    public static Call<List<Seat>> getAvailableSeats(int idFilm, int idDvorane, String casZacetka,
                                                     String casKonca, String datum) {
        return myRetrofit
                .create(GetAvailableSeats.class)
                .getAvailableSeats(idFilm, idDvorane, casZacetka, casKonca, datum);
    }


    public static Call<String> makeTicketOrder(TicketData myTicket) {
        return myRetrofit
                .create(MakeTicketOrder.class)
                .makeTicketOrder(myTicket);
    }



}
