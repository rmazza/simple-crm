import { Component, OnInit } from '@angular/core';

import { DashboardMenu } from '../entities/main-menu';
import { MegaMenuItem } from 'primeng/api';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public items: MegaMenuItem[];
  
  constructor( ) {
  
   }

  ngOnInit(): void {
    this.items = DashboardMenu.items;
  }

}
