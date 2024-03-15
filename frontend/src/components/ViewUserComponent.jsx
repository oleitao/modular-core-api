import React, { Component } from 'react'
import UserService from '../services/UserService'

class ViewUserComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            id: this.props.match.params.id,
            user: {}
        }
    }

    componentDidMount(){
        UserService.getUserById(this.state.id).then( res => {
            this.setState({user: res.data});
        })
    }

    render() {
        return (
            <div>
                <br></br>
                <div className = "card col-md-6 offset-md-3">
                    <h3 className = "text-center"> View User Details</h3>
                    <div className = "card-body">
                        <div className = "row">
                            <label> Name: </label>
                            <div> { this.state.user.fullName }</div>
                        </div>
                        <div className = "row">
                            <label> Sex: </label>
                            <div> { this.state.user.sex }</div>
                        </div>
                        <div className = "row">
                            <label> Age: </label>
                            <div> { this.state.user.age }</div>
                        </div>
                        <div className = "row">
                            <label> Hobby: </label>
                            <div> { this.state.user.hobby }</div>
                        </div>
                        <div className = "row">
                            <label> Email: </label>
                            <div> { this.state.user.email }</div>
                        </div>
                    </div>

                </div>
            </div>
        )
    }
}

export default ViewUserComponent
