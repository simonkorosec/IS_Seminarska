package myapp.kinoisseminarska.webservices;

import java.util.List;

import myapp.kinoisseminarska.dataholder.ReturnTicketData;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface GetAllTicketsByUser {

    @GET("UporabnikApi/{username}/")
    Call<List<ReturnTicketData>> getAllTicketsByUser(@Path("username") String username);
}
