package myapp.kinoisseminarska.views;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.webservices.RestManagment;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;


public class SeatsFragment extends Fragment {

    private OnFragmentInteractionListener mListener;

    public SeatsFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootContainer = inflater.inflate(R.layout.fragment_seats, container, false);


        RestManagment.getAvailableSeats(
                5, 3,"18:00:00", "20:00:00","2019-02-15"

        ).enqueue(new Callback<List<Seat>>() {
            @Override
            public void onResponse(Call<List<Seat>> call, Response<List<Seat>> response) {

                Log.d("test_is", response.code() + "");
                if(response.code() == 200) {
                    Log.d("test_is", "api works");
                    List<Seat> mySeats = response.body();
                    Log.d("test_si", mySeats.size() + " size is");
                }
            }

            @Override
            public void onFailure(Call<List<Seat>> call, Throwable t) {
                Log.d("test_is", "api '/SedezAPI' failed");
            }
        });



        return rootContainer;
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnFragmentInteractionListener) {
            mListener = (OnFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    public interface OnFragmentInteractionListener {
        void onFragmentInteraction(Uri uri);
    }
}
