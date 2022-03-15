import { Component, OnInit,EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {


  drawerOpen: boolean = false;
  @Output() drawerUpdate: EventEmitter<any> = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  updateDrawer(): void {
    this.drawerOpen = !this.drawerOpen;
    this.drawerUpdate.emit(this.drawerOpen);

  }
}
