import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CurrencyResponse, CurrencyType } from '../../types';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {
  private _url = 'https://localhost:7105/currency';
  constructor(private http: HttpClient) { }
  
  public async getCurrencies(): Promise<Observable<CurrencyResponse>> {
    return this.http.get<CurrencyResponse>(this._url);
  }
}
