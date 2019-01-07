package myapp.kinoisseminarska.views;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Random;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.dataholder.Show;
import myapp.kinoisseminarska.dataholder.TicketData;
import myapp.kinoisseminarska.utils.ContentStore;
import myapp.kinoisseminarska.webservices.RestManagment;
import okhttp3.ResponseBody;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class OrderTicketActivity extends AppCompatActivity {

    private TextView imeFilma;
    private TextView imeDvorane;
    private TextView sedez;
    private TextView casZacetka;
    private TextView casKonca;
    private TextView datum;
    private TextView cena;
    private LinearLayout nakupButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_order_ticket);

        imeFilma = findViewById(R.id.imeFilmaValue);
        imeDvorane = findViewById(R.id.imeDvoraneValue);
        sedez = findViewById(R.id.sedezValue);
        casZacetka = findViewById(R.id.casZacetkaTicketValue);
        casKonca = findViewById(R.id.casKoncaTicketValue);
        datum = findViewById(R.id.datumTicketValue);
        cena = findViewById(R.id.cenaTicketValue);
        nakupButton = findViewById(R.id.nakupButton);

        final Intent passedIntent = getIntent();
        if (passedIntent != null) {
            Show passedShow = (Show) passedIntent.getSerializableExtra("passed_show");
            final Seat passedSeat = (Seat) passedIntent.getSerializableExtra("passed_seat");
            if(passedShow != null && passedSeat != null) {

                float myPrice = randPrice();
                String price = String.format("%.2f", myPrice);

                imeFilma.setText(passedShow.getNaslovFilma());
                imeDvorane.setText(passedShow.getImeDvorane());
                sedez.setText("vrsta: " + passedSeat.getVrsta() + ", stevilka: " + passedSeat.getStevilka());
                casZacetka.setText(passedShow.getCasZacetka());
                casKonca.setText(passedShow.getCasKonca());
                datum.setText(passedShow.getDatum());
                cena.setText(price + " €");

                final TicketData myTicket = new TicketData();
                myTicket.setIdFilm(passedShow.getIdFilma());
                myTicket.setIdDvorane(passedShow.getIdDvorane());
                myTicket.setIdSedeza(passedSeat.getIdSedeza());
                myTicket.setCasZacetka(passedShow.getCasZacetka());
                myTicket.setCasKonca(passedShow.getCasKonca());
                myTicket.setDatum(passedShow.getDatum());
                myTicket.setCena(myPrice);

                ContentStore cntStore = new ContentStore(getApplicationContext());
                myTicket.setUsername(cntStore.getUsername());
                Log.d("test_is", myTicket.getUsername() + " ticket username");

                nakupButton.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        RestManagment.makeTicketOrder(myTicket).enqueue(new Callback<ResponseBody>() {
                            @Override
                            public void onResponse(Call<ResponseBody> call, Response<ResponseBody> response) {
                                if(response.code() == 200) {
                                    Log.d("test_is", "Purchased a ticket for seat: vrsta: "
                                            + passedSeat.getVrsta() + " stevilka: " + passedSeat.getStevilka());
                                    Toast.makeText(getApplicationContext(),
                                            "Uspesno opravljena rezervacija :)",
                                            Toast.LENGTH_SHORT).show();
                                    finish();
                                }
                                else
                                    Log.d("test_is", "invalid response code: " + response.code());
                            }
                            @Override
                            public void onFailure(Call<ResponseBody> call, Throwable t) {
                                Log.d("test_is", "api 'NakupAPI/' failed");
                            }
                        });
                    }
                });
            }
        }
    }

    private float randPrice() {
        return 5.5f + new Random().nextFloat() * ( 6.8f - 5.5f);
    }
}
