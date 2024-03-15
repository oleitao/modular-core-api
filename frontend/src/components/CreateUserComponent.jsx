import React, { Component } from 'react'
import UserService from '../services/UserService';

class CreateUserComponent extends Component {
    constructor(props) {
        super(props)
        this.state = {
            
            id: this.props.match.params.id,
            fullName: '',
            sex: '',
            age: 0,
            hobby:'',
            email: '',
            errorMessage: ''
        }

        this.changeNameHandler = this.changeNameHandler.bind(this);
        this.changeSexHandler = this.changeSexHandler.bind(this);
        this.changeAgeHandler = this.changeAgeHandler.bind(this);
        this.changeHobbyHandler = this.changeHobbyHandler.bind(this);
        this.saveOrUpdateUser = this.saveOrUpdateUser.bind(this);
    }

    componentDidMount() {
       
        if (this.state.id === '_add') {
            return
        } else {
            UserService.getUserById(this.state.id).then((res) => {
                let user = res.data;
                this.setState({
                    fullName: user.fullName,
                    sex: user.sex,
                    age: user.age,
                    hobby: user.hobby,
                    email: user.email        
                });
            });
        }
    }
    
    saveOrUpdateUser = (e) => {
        e.preventDefault();

        let user = {          
            fullName: this.state.fullName, 
            sex: this.state.sex, 
            age: this.state.age, 
            hobby: this.state.hobby, 
            email: this.state.email 
        };

        //console.log('user => ' + JSON.stringify(user));
     
        if (this.state.id === '_add') {
            UserService.createUser(user).then(res => {
                this.props.history.push('/users');
            },err => this.setState({errorMessage: err.message}));
        } else {
            UserService.updateUser(user, this.state.id).then(res => {
                this.props.history.push('/users');
            },err => this.setState({errorMessage: err.message}));
        }
    }
    
    changeNameHandler = (event) => {
        this.setState({ fullName: event.target.value });
    }

    changeSexHandler = (event) => {
        this.setState({ sex: event.target.value });
    }

    changeAgeHandler = (event) => {
        this.setState({ age: event.target.value });
    }

    changeHobbyHandler = (event) => {
        this.setState({ hobby: event.target.value });
    }

    changeEmailHandler = (event) => {
        this.setState({ email: event.target.value });
    }

    cancel() {
        this.props.history.push('/users');
    }

    getTitle() {
        if (this.state.id === '_add') {
            return <h3 className="text-center">Add User</h3>
        } else {
            return <h3 className="text-center">Update User</h3>
        }
    }
    render() {
        return (
            <div>
                <br></br>
                <div className="container">
                    <div className="row">
                        <div className="card col-md-6 offset-md-3 offset-md-3">
                            {
                                this.getTitle()
                            }
                            <div className="card-body">
                                <form>
                                    <div className="form-group">
                                        <label> Name: </label>
                                        <input placeholder="Name" name="fullName" className="form-control"
                                            value={this.state.fullName} onChange={this.changeNameHandler} />
                                    </div>
                                    <div className="form-group">
                                        <label> Sex: </label>
                                        <input placeholder="Sex" name="sex" className="form-control"
                                            value={this.state.sex} onChange={this.changeSexHandler} />
                                    </div>
                                    <div className="form-group">
                                        <label> Age: </label>
                                        <input placeholder="Age" name="age" className="form-control"
                                            value={this.state.age} onChange={this.changeAgeHandler} />
                                    </div>
                                    <div className="form-group">
                                        <label> Hobby: </label>
                                        <input placeholder="Hobby" name="hobby" className="form-control"
                                            value={this.state.hobby} onChange={this.changeHobbyHandler} />
                                    </div>
                                    <div className="form-group">
                                        <label> Email Id: </label>
                                        <input placeholder="Email Address" name="email" className="form-control"
                                            value={this.state.email} onChange={this.changeEmailHandler} />
                                    </div>

                                    <button className="btn btn-success" onClick={this.saveOrUpdateUser}>Save</button>
                                    <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{ marginLeft: "10px" }}>Cancel</button>
                                    
                                    { this.state.errorMessage &&
                                    <h5 className="alert alert-danger"> 
                                    { this.state.errorMessage } </h5> }
                                </form>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        )
    }
}

export default CreateUserComponent
