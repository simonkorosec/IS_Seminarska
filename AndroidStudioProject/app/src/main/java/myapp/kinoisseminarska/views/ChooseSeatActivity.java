package myapp.kinoisseminarska.views;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.dataholder.SeatQuery;
import myapp.kinoisseminarska.dataholder.Show;
import myapp.kinoisseminarska.utils.adapters.SeatsRecyclerAdapter;
import myapp.kinoisseminarska.webservices.RestManagment;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ChooseSeatActivity extends AppCompatActivity {

    private TextView numOfSeatsText;
    private RecyclerView seatRecyclerView;
    private SeatsRecyclerAdapter seatsAdapter;
    private LinearLayoutManager linearLayoutManager;
    private List<Seat> mySeats;
    private ProgressBar seatProgessBar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_choose_seat);

        numOfSeatsText = findViewById(R.id.numSeatsText);
        linearLayoutManager = new LinearLayoutManager(getApplicationContext());
        seatRecyclerView = findViewById(R.id.seatRecyclerView);
        seatProgessBar = findViewById(R.id.seatProgressBar);
        seatProgessBar.setVisibility(View.VISIBLE);
        mySeats = new ArrayList<>();

        Intent myIntent = getIntent();
        if(myIntent != null) {
            final Show passedShow = (Show) myIntent.getSerializableExtra("show_info");

            SeatQuery mySeatQuery = new SeatQuery();
            mySeatQuery.setIdDvorane(passedShow.getIdDvorane());
            mySeatQuery.setIdFilm(passedShow.getIdFilma());
            mySeatQuery.setCasZacetka(passedShow.getCasZacetka());
            mySeatQuery.setCasKonca(passedShow.getCasKonca());
            mySeatQuery.setDatum(passedShow.getDatum());

            RestManagment.getAvailableSeats(mySeatQuery).enqueue(new Callback<List<Seat>>() {
                @Override
                public void onResponse(Call<List<Seat>> call, Response<List<Seat>> response) {
                    if (response.code() == 200) {
                        mySeats = response.body();
                        Log.d("test_is", "Current num of seats for show: " + mySeats.size());
                        numOfSeatsText.setText(String.valueOf(mySeats.size()));
                        Collections.sort(mySeats);
                        seatProgessBar.setVisibility(View.GONE);

                        seatsAdapter = new SeatsRecyclerAdapter(mySeats, passedShow);
                        seatRecyclerView.setLayoutManager(linearLayoutManager);
                        seatRecyclerView.setAdapter(seatsAdapter);
                    }
                }

                @Override
                public void onFailure(Call<List<Seat>> call, Throwable t) {
                    Log.d("test_is", "api '/SedezAPI' failed");

                }
            });


        }


    }
}
