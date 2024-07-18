import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Unit } from '../models/unit.model';

@Injectable({
  providedIn: 'root'
})
export class UnitService {
  private apiUrl = 'https://localhost:7162/api/groups';

  constructor(private http: HttpClient) { }

  getAllUnits(): Observable<Unit[]> {
    return this.http.get<Unit[]>(this.apiUrl);
  }

  getUnitById(id: number): Observable<Unit> {
    return this.http.get<Unit>(`${this.apiUrl}/${id}`);
  }

  addUnit(unit: Unit): Observable<Unit> {
    return this.http.post<Unit>(this.apiUrl, unit);
  }

  updateUnit(id: number, unit: Unit): Observable<Unit> {
    return this.http.put<Unit>(`${this.apiUrl}/${id}`, unit);
  }

  deleteUnit(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
