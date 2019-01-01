package myapp.kinoisseminarska.webservices;

import myapp.kinoisseminarska.dataholder.TicketData;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;

public interface MakeTicketOrder {

    // make a ticket order to a server
    @POST("NakupAPI/")
    Call<String> makeTicketOrder(@Body TicketData ticket);
}
