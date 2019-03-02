import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ProductToSectionRequest } from '../models/product-section-request';


@Injectable({
    providedIn: 'root'
})

export class ProductToSectionRequestsService {
    private url = environment.apiUrl + 'api/productRequests';

    constructor(private http: HttpClient) { }

    getProductToSectionRequests():Observable<Array<ProductToSectionRequest>> {
        return this.http.get<Array<ProductToSectionRequest>>(`${this.url}`);
    }

    confirmRequest(requestId: number): Observable<Object> {
        return this.http.put(`${this.url}/${requestId}/confirm`, null);
    }

    rejectRequest(requestId: number): Observable<Object> {
        return this.http.put(`${this.url}/${requestId}/reject`, null);
    }

    createRequest(productToSectionRequest: ProductToSectionRequest):Observable<ProductToSectionRequest>{
        return this.http.post<ProductToSectionRequest>(`${this.url}`,productToSectionRequest);
    }

}
