import { environment } from './../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Transaction } from '../interfaces/transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {

  constructor(private httpClient: HttpClient) { }

  getTransactions(): Observable<Transaction[]>{
    const url = environment.baseUrl + 'transaction';
    return this.httpClient.get<Transaction[]>(url);
  }
}
