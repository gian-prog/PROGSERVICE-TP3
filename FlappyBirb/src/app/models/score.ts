export class Score{

    constructor(
        public id : number,
        public pseudo : string | null,
        public date : string | null,
        public temps : string,
        public score : number,
        public visibilite : boolean
    ){}

}