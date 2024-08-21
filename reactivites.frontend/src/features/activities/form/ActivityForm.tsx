import { ChangeEvent, useEffect, useState } from "react";
import { Button, Form, FormField, FormInput, FormTextArea, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { observer} from "mobx-react-lite";
import { Link, useNavigate, useParams } from "react-router-dom";
import { Activity } from "../../../app/models/activity";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import {v4 as uuid} from 'uuid';


export default observer(function ActivityForm()
{
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loading, loadActivity, loadingInitial} = activityStore;
    const {id} = useParams();
    const navigate = useNavigate();
    const [activity, setActivity] = useState<Activity>({
        id: '',
        title: '',
        category: '',
        description: '',
        date: '',
        city: '',
        venue: ''
    })

    useEffect(() => {
        if(id) {
            loadActivity(id).then(act => setActivity(act!));
        }
    }, [id, loadActivity])

    function handlerSumbit()
    {
        if(!activity.id){
            activity.id = uuid()
            createActivity(activity).then(() => navigate(`/activities/${activity.id}`));
            

        }else {
            updateActivity(activity).then(() =>navigate(`/activities/${activity.id}`));
            
        }
        activity.id ? updateActivity(activity) : createActivity(activity);
    }
    
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>)
    {
        const {name, value} = event.target;
        setActivity({...activity, [name]: value})
    }

    if(loadingInitial) return <LoadingComponent content="Loading activity..." />
    return (
        <div>
        <Segment clearing>
        <Form onSubmit={handlerSumbit} autoComplete='off'>
            <FormField>
            <FormInput placeholder='Title'  value={activity.title} name='title' onChange={handleInputChange} />
            </FormField>
            <FormField>
            <FormTextArea placeholder='Description' value={activity.description} name='description' onChange={handleInputChange}/>
            </FormField>

            <FormField>
            <FormInput placeholder='Category' value={activity.category} name='category' onChange={handleInputChange}/>
            </FormField>

            <FormField>
            <FormInput placeholder='Date' type="date" value={activity.date} name='date' onChange={handleInputChange}/>
            </FormField>

            <FormField>
            <FormInput placeholder='City' value={activity.city} name='city' onChange={handleInputChange}/>
            </FormField>


            <FormField>
            <FormInput placeholder='Venu' value={activity.venue} name='venue' onChange={handleInputChange}/>
            </FormField>

            <FormField>
            <Button loading={loading} positive  floated="right" content="Submit" type="submit" />
            <Button floated="right" content="Cancel" as={Link} to="/activities" />
            </FormField>
            
         </Form>
        </Segment>
        </div>
    )
})