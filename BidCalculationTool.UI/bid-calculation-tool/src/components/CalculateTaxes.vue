<template>
  <div v-if="loading" class="loader"></div>
  <div v-else>
    <div class="form-container">
      <form>
        <div class="form-group">
          <label for="price">Price</label>
          <input type="number" id="price" v-model="price" @blur="calculate" required />
        </div>
        <div class="form-group">
          <label for="vehicleType">Vehicle Type</label>
          <select id="vehicleType" v-model="vehicleType" @change="calculate" required>
            <option value="" disabled>Select a vehicle type</option>
            <option value="1">Common</option>
            <option value="2">Luxury</option>
          </select>
        </div>
      </form>
    </div>

    <div class="container">
      <div class="ag-theme-alpine">
        <h3>Calculated Fees</h3>
        <ag-grid-vue
          :rowData="rowData"
          :columnDefs="colDefs"
          style="height: 500px; width: 800px"
          class="ag-theme-quartz"
        >
        </ag-grid-vue>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import { ref } from 'vue'
import { AgGridVue } from 'ag-grid-vue3'
import 'ag-grid-community/styles/ag-grid.css'
import 'ag-grid-community/styles/ag-theme-alpine.css'

export default {
  components: {
    AgGridVue
  },
  setup() {
    const price = ref(0)
    const vehicleType = ref('')
    const rowData = ref([])
    const loading = ref(false)
    const colDefs = ref([
      { field: 'base', valueFormatter: (p) => '$' + p.value },
      { field: 'seller', valueFormatter: (p) => '$' + p.value },
      { field: 'storage', valueFormatter: (p) => '$' + p.value },
      { field: 'total', valueFormatter: (p) => '$' + p.value }
    ])

    const calculate = async () => {
      try {
        if (price.value === 0 || vehicleType.value === '') {
          return
        }
        loading.value = true
        const response = await axios.get(
          `https://localhost:7197/calculate-fees/${price.value}/${vehicleType.value}`,
          {
            headers: {
              'Access-Control-Allow-Origin': '*',
              'Content-Type': 'application/json'
            }
          }
        )
        rowData.value = [{ ...response.data }]
      } catch (error) {
        console.error('Error:', error)
      } finally {
        loading.value = false
      }
    }

    return {
      price,
      vehicleType,
      colDefs,
      rowData,
      calculate,
      loading
    }
  }
}
</script>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  align-items: center;
}

.form-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  max-width: 500px;
  width: 100%;
  padding: 2rem;
  border: 1px solid #ddd;
  border-radius: 10px;
  background-color: #fff;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.form-group {
  width: 100%;
  margin-bottom: 1.5rem;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: bold;
  color: #333;
}

input,
select {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.loader {
  border: 4px solid #f3f3f3;
  border-radius: 50%;
  border-top: 4px solid #3498db;
  width: 40px;
  height: 40px;
  animation: spin 2s linear infinite;
  margin: auto;
}

@media (min-width: 768px) {
  .form-container {
    padding: 3rem;
  }

  button {
    width: auto;
    padding: 1rem 3rem;
  }
}
</style>
