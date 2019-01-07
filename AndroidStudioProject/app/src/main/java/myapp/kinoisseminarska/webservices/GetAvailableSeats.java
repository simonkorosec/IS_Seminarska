package myapp.kinoisseminarska.webservices;

import java.util.List;

import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.dataholder.SeatQuery;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface GetAvailableSeats {

    //get list of all available seats for passed SeatQuery info
    @POST("SedezAPI/")
    Call<List<Seat>> getAvailableSeats(@Body SeatQuery mySeatQuery);
}
