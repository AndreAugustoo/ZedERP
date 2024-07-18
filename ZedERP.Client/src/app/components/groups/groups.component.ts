import { Component, OnInit } from '@angular/core';
import { GroupService } from '../../services/group.service';
import { Group } from '../../models/group.model';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {
  groups: Group[] = [];

  constructor(private groupService: GroupService) { }

  ngOnInit(): void {
    this.loadGroups();
  }

  loadGroups() {
    this.groupService.getAllGroups().subscribe((data: Group[]) => {
      this.groups = data;
    });
  }
}
