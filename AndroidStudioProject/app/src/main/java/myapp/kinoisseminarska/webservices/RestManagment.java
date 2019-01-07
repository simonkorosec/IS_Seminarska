package myapp.kinoisseminarska.webservices;

import java.util.List;

import myapp.kinoisseminarska.dataholder.ReturnTicketData;
import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.dataholder.SeatQuery;
import myapp.kinoisseminarska.dataholder.Show;
import myapp.kinoisseminarska.dataholder.TicketData;
import myapp.kinoisseminarska.dataholder.User;
import okhttp3.ResponseBody;
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

    public static Call<List<Seat>> getAvailableSeats(SeatQuery mySeatQuery) {
        return myRetrofit
                .create(GetAvailableSeats.class)
                .getAvailableSeats(mySeatQuery);
    }


    public static Call<ResponseBody> makeTicketOrder(TicketData myTicket) {
        return myRetrofit
                .create(MakeTicketOrder.class)
                .makeTicketOrder(myTicket);
    }

    public static Call<ResponseBody> loginUser(User user) {
        return myRetrofit
                .create(LoginUser.class)
                .loginUser(user);
    }

    public static Call<ResponseBody> registerUser(User user) {
        return myRetrofit
                .create(RegisterUser.class)
                .registerUser(user);
    }

    public static Call<List<ReturnTicketData>> getAllTicketsByUser(String username) {
        return myRetrofit
                .create(GetAllTicketsByUser.class)
                .getAllTicketsByUser(username);
    }



}
