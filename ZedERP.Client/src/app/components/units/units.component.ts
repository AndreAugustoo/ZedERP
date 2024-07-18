import { Component, OnInit } from '@angular/core';
import { UnitService } from '../../services/unit.service';
import { Unit } from '../../models/unit.model';

@Component({
  selector: 'app-units',
  templateUrl: './units.component.html',
  styleUrls: ['./units.component.css']
})
export class UnitsComponent implements OnInit {
  units: Unit[] = [];

  constructor(private unitService: UnitService) { }

  ngOnInit(): void {
    this.loadUnits();
  }

  loadUnits() {
    this.unitService.getAllUnits().subscribe((data: Unit[]) => {
      this.units = data;
    });
  }
}
