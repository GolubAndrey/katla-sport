export class User {
    constructor(
        public id: String,
        public userName: String,
        public password: String,
        public firstName: String,
        public lastName: String,
        public roles: String[],
    ) { }
}
