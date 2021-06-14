import { Component, OnInit } from "@angular/core";
import { Note, REMAINDERS, USER, IS_NOTIFIED } from "../model/note-model";
import { NotesService } from "../notes.service";

@Component({
  selector: "app-reminders",
  templateUrl: "./reminders.component.html",
  styleUrls: ["./reminders.component.css"],
})
export class RemindersComponent implements OnInit {
  user = USER;
  notes: Array<Note> = [];
  reminders = REMAINDERS;
  constructor(private notesService: NotesService) {}

  ngOnInit() {
    this.notesService.getNotes(this.user.Id).subscribe(
      (res) => {
        
        this.notes = this.fitlerNotes(res);
      },
      (err) => {
        console.log(err);
      }
    );
  }
  sendMail(note:Note) {
    note.notified = IS_NOTIFIED; 
    this.notesService.sendEmail(note).subscribe(
      (res) => {
        this.notes = this.fitlerNotes(res)
      },
      (err) => {
        console.log(err);
      }
    );
  }

  fitlerNotes(notes:Array<Note>):Array<Note> {

      return notes.filter((n) => this.calculateDiff(n.noteDate) === n.reminder && n.notified !== IS_NOTIFIED)
  }

  calculateDiff(sentDate) {
    var date1: any = new Date(sentDate);
    var date2: any = new Date();
    var diffDays: any = Math.floor(( date1 - date2 ) / (1000 * 60 * 60 * 24));

    return diffDays;
  }
}
