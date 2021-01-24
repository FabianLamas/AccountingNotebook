import { TransactionsService } from './../services/transactions.service';
import { Transaction } from './../interfaces/transaction';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnInit {

  public transactions$: Observable<Transaction[]> = new Observable<Transaction[]>();
  
  constructor(private service: TransactionsService) { }

  ngOnInit(): void {
    this.getTransactions();
  }

  getTransactions(){
    this.transactions$ = this.service.getTransactions();
  }
}
