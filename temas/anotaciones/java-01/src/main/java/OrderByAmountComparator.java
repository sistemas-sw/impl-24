package main.java;

import java.util.Comparator;

public class OrderByAmountComparator implements Comparator<Order> {
    @Override
    public int compare(Order o1, Order o2) {
        return Double.compare(o1.getAmount(), o2.getAmount());
    }
}
