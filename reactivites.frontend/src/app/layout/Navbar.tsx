import { Button, Container, Menu, MenuItem } from "semantic-ui-react";
import { NavLink } from "react-router-dom";

export default function Navbar() {
    return (
        <div>
        <Menu inverted fixed="top">
            <Container>
                <MenuItem as={NavLink} to="/" header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}} />
                    Reactivities
                </MenuItem>
                <MenuItem as={NavLink} to="/activities" name="Activities" />
                <MenuItem>
                <Button as={NavLink} to="/createActivity" positive content="Create Activity"/>
                </MenuItem>
            </Container>

        </Menu>
        </div>
    )
}