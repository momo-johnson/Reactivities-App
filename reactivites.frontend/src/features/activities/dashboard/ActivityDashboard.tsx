import { useEffect } from "react";
import { Grid, GridColumn} from "semantic-ui-react";
import ActivityList from "./ActivityList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import ActivityFilter from "./ActivityFilters";


export default observer(function ActivityDashboard() {
    const { activityStore } = useStore();
    const {loadActivities, activityRegistry} = activityStore

    useEffect(() => {
        if(activityRegistry.size <= 1) loadActivities()
     }, [loadActivities, activityRegistry])
 
     if(activityStore.loadingInitial) return <LoadingComponent inverted={true} content='Loading App...' />
    return (
        <div>
        <Grid>
            <GridColumn width='10' style={{marginLeft: 'auto', marginRight: 'auto'}}>
           <ActivityList />
            </GridColumn>
            <Grid.Column width={6}>
                <ActivityFilter />
            </Grid.Column>
        </Grid>
        </div>
    )
})