import { Purchase } from "./purchase";

export interface LoyaltyPoint {
    customerDetails: string;
    pointValue: number;
    pointCashValue: string;
    purchases: Purchase[];
  }