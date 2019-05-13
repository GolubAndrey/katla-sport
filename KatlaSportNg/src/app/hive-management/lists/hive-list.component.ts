import { Component, OnInit } from '@angular/core';
import { HiveListItem } from '../models/hive-list-item';
import { HiveService } from '../services/hive.service';
import { UserService } from 'app/login-managment/services/login.service';

@Component({
  selector: 'app-hive-list',
  templateUrl: './hive-list.component.html',
  styleUrls: ['./hive-list.component.css']
})
export class HiveListComponent implements OnInit {

  hives: HiveListItem[];

  constructor(
    private hiveService: HiveService,
    private userService: UserService
    ) { }

  ngOnInit() {
    this.getHives();
  }

  getHives() {
    this.hiveService.getHives().subscribe(h => this.hives = h);
  }

  onDelete(hiveId: number) {
    var hive = this.hives.find(h => h.id == hiveId);
    this.hiveService.setHiveStatus(hiveId, true).subscribe(c => hive.isDeleted = true);
  }

  onRestore(hiveId: number) {
    var hive=this.hives.find(h => h.id == hiveId);
    this.hiveService.setHiveStatus(hiveId, false).subscribe(c=>hive.isDeleted = false);
  }
}
