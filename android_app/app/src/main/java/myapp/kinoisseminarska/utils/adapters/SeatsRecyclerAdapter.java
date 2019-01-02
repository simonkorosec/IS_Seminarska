package myapp.kinoisseminarska.utils.adapters;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.Seat;
import myapp.kinoisseminarska.dataholder.Show;


public class SeatsRecyclerAdapter
        extends RecyclerView.Adapter<SeatsRecyclerAdapter.SeatsRecyclerHolder> {

    private List<Seat> seats;
    @NonNull
    private Show currentSeat;

    // Define the View Holder
    static class SeatsRecyclerHolder extends RecyclerView.ViewHolder {
        LinearLayout cardContainer;
        TextView imeDvoraneText;
        TextView vrstaText;
        TextView stevilkaSedezaText;

        SeatsRecyclerHolder(final View itemView) {
            super(itemView);
            // Initialize the parameters based on the Card layout names
            cardContainer = itemView.findViewById(R.id.cardSeatContainer);
            imeDvoraneText = itemView.findViewById(R.id.dvoranaSeatsText);
            vrstaText = itemView.findViewById(R.id.vrstaText);
            stevilkaSedezaText = itemView.findViewById(R.id.stevilkaText);
        }
    }

    // Adapter constructor
    public SeatsRecyclerAdapter(List<Seat> seats) {
        this.seats = seats;
    }
    /*
    onCreateViewHolder, onBindViewHolder and getItemCount() HAVE to be defined in order to get rid
    of the errors!
    */

    @NonNull
    @Override
    public SeatsRecyclerHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View cardSeatView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.card_seat, parent, false);

        return new SeatsRecyclerHolder(cardSeatView);
    }

    @Override
    public void onBindViewHolder(@NonNull final SeatsRecyclerHolder holder, int position) {
        // Get the restaurant home info for the appropriate restaurant
        Seat seatInfo = this.seats.get(position);
        final Context myContext = holder.imeDvoraneText.getContext();

        holder.imeDvoraneText.setText(seatInfo.getImeDvorane());
        holder.vrstaText.setText("vrsta: " + seatInfo.getVrsta() + "");
        holder.stevilkaSedezaText.setText("stevilka: " + seatInfo.getStevilka() + "");


        holder.cardContainer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                /*
                currentSeat = seats.get(holder.getAdapterPosition());
                Intent myIntent = new Intent(myContext, ChooseSeatActivity.class);
                myIntent.putExtra("show_info", currentSeat);
                myContext.startActivity(myIntent);
                */
            }
        });
    }

    @Override
    public int getItemCount() {
        return seats.size();
    }

}
