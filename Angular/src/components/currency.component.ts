import { Component } from '@angular/core';
import { CurrencyResponse, CurrencyType } from '../types';
import { CurrencyService } from '../services/currencies/currency.service';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'currency-root',
  templateUrl: './currency.component.html',
  styleUrl: './currency.component.css',
})

export class CurrencyComponent {
  title = 'exchange';
  error: string = '';
  defaultSelection = {currency: 'Select', rate: 0};
  currencies: CurrencyType[] = [];
  applyForm = new FormGroup({
    from: new FormControl(''),
    to: new FormControl(''),
    amount: new FormControl(100)
  })
  exchangeAmount: Number = 0;

  constructor(private _cs: CurrencyService) {
  }

  async ngOnInit() {
    (await this._cs.getCurrencies())
        .subscribe((data: CurrencyResponse) => {
            this.currencies = [this.defaultSelection].concat(data.currencyList)},
            (err: HttpErrorResponse) => {
                if (err.status === 0) { this.error = 'Servisas neatsako' }
                else if (err.status === 500) { this.error = 'Duomenu nerasta' }
                else this.error = 'Nezinoma klaida';
            }
        );
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    if (!this.applyForm.valid) this.error = 'Prasom pasirinkti valiuta keitimui atlikti';
    if (this.applyForm.value.from === this.applyForm.value.to) this.error = 'Prasom pasirinkti skirtingas valiutas!';
    if (this.applyForm.value.from && this.applyForm.value.to) this.error = 'Skaiciavimo Klaida';

    const fromRate = this.currencies.find(x => x.currency === this.applyForm.value.from)?.rate;
    const toRate = this.currencies.find(x => x.currency === this.applyForm.value.to)?.rate;

    if (fromRate && toRate && this.applyForm.value.amount) {
      const dollarValue = (fromRate * this.applyForm.value.amount);
      this.exchangeAmount = dollarValue * toRate;
      this.applyForm.reset();
      this.error = '';
    };
  }
}
