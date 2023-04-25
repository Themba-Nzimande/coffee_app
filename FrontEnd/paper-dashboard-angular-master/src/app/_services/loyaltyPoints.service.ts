import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { LoyaltyPoint } from 'app/_models/loyaltyPoint';

@Injectable({
  providedIn: 'root'
})
export class LoyaltyPointsService {
  //baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getLoyaltyPoints(phoneNumber?) {
    if (phoneNumber == null) {
        console.log('MADE IT TO SERVICE');
        return this.http.get<LoyaltyPoint[]>('https://localhost:7141/api/LoyaltyPoints/GetAllCustomerLoyaltyPoints'); 
    } else {
        return this.http.get<LoyaltyPoint[]>('https://localhost:5100/api/LoyaltyPoints/GetCustomerLoyaltyPoints?customerPhoneNumber=' + phoneNumber);
    }
  }

 
}