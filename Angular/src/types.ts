export interface CurrencyResponse {
    currencyList: CurrencyType[];
}

export interface CurrencyType {
    currency: string;
    rate: number;
}

export interface CurrencyQuery {
    from: string;
    to: string;
}