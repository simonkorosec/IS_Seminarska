package myapp.kinoisseminarska.utils.adapters;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.List;

import myapp.kinoisseminarska.R;
import myapp.kinoisseminarska.dataholder.ReturnTicketData;


public class ReturnedTicketsRecyclerAdapter
        extends RecyclerView.Adapter<ReturnedTicketsRecyclerAdapter.ReturnedTicketsRecyclerHolder> {

    private List<ReturnTicketData> tickets;
    @NonNull
    private ReturnTicketData currentTicket;

    // Define the View Holder
    static class ReturnedTicketsRecyclerHolder extends RecyclerView.ViewHolder {
        LinearLayout cardContainer;
        TextView imeFilmaText;
        TextView cena;
        TextView casZacetkaText;
        TextView casKoncaText;
        TextView datumText;

        ReturnedTicketsRecyclerHolder(final View itemView) {
            super(itemView);
            // Initialize the parameters based on the Card layout names
            cardContainer = itemView.findViewById(R.id.cardVstopnicaContainer);
            imeFilmaText = itemView.findViewById(R.id.imeFilmaVstopnicaText);
            cena = itemView.findViewById(R.id.cenaVstopnicaText);
            casZacetkaText = itemView.findViewById(R.id.casZacetkaVstopnicaText);
            casKoncaText = itemView.findViewById(R.id.casKoncaVstopnicaText);
            datumText = itemView.findViewById(R.id.datumVstopnicaText);
        }
    }

    // Adapter constructor
    public ReturnedTicketsRecyclerAdapter(List<ReturnTicketData> seats) {
        this.tickets = seats;
    }
    /*
    onCreateViewHolder, onBindViewHolder and getItemCount() HAVE to be defined in order to get rid
    of the errors!
    */

    @NonNull
    @Override
    public ReturnedTicketsRecyclerHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View cardTicketView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.card_ticket, parent, false);

        return new ReturnedTicketsRecyclerHolder(cardTicketView);
    }

    @Override
    public void onBindViewHolder(@NonNull final ReturnedTicketsRecyclerHolder holder, int position) {
        // Get the restaurant home info for the appropriate restaurant
        ReturnTicketData ticketInfo = this.tickets.get(position);

        holder.imeFilmaText.setText(ticketInfo.getNaslov());
        holder.cena.setText(String.format("%.2f €" , ticketInfo.getCena()));
        holder.casZacetkaText.setText(ticketInfo.getCasZacetka());
        holder.casKoncaText.setText(ticketInfo.getCasKonca());
        holder.datumText.setText(ticketInfo.getDatum());
    }

    @Override
    public int getItemCount() {
        return tickets.size();
    }

}
