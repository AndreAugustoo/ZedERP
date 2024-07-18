import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Group } from '../models/group.model';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  private apiUrl = 'https://localhost:7162/api/groups';

  constructor(private http: HttpClient) { }

  getAllGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(this.apiUrl);
  }

  getGroupById(id: number): Observable<Group> {
    return this.http.get<Group>(`${this.apiUrl}/${id}`);
  }

  addGroup(group: Group): Observable<Group> {
    return this.http.post<Group>(this.apiUrl, group);
  }

  updateGroup(id: number, group: Group): Observable<Group> {
    return this.http.put<Group>(`${this.apiUrl}/${id}`, group);
  }

  deleteGroup(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
