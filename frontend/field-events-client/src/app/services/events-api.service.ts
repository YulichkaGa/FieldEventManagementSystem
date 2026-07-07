import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventsApiService {
  private baseUrl = 'http://localhost:5129/api/Events';

  constructor(private http: HttpClient) {}

  getEvents(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  assignTechnician(eventId: string): Observable<any> {
    return this.http.put(`${this.baseUrl}/assign`, {
      eventId,
      technicianName: 'David Cohen'
    });
  }
}
